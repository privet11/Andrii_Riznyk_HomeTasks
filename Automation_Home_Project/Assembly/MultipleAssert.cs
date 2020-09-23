﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.Assembly
{
    public class Multiple
    {
        private StringBuilder Errors { get; set; }
        private bool AssertsPassed { get; set; }

        private string AccumulatedErrorMessage
        {
            get
            {
                return Errors.ToString();
            }
        }

        public Multiple()
        {
            Errors = new StringBuilder();
            AssertsPassed = true;
        }

        private void RegisterError(string exceptionMessage)
        {
            AssertsPassed = false;
            Errors.AppendLine(exceptionMessage);
        }

        public void Accumulate(Action assert)
        {
            try
            {
                assert.Invoke();
            }
            catch (Exception exception)
            {
                RegisterError(exception.Message);
            }
        }

        public void Release()
        {
            if (!AssertsPassed)
            {
                throw new AssertionException(AccumulatedErrorMessage);
            }
        }
    }
}
