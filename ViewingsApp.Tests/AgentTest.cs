using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Services;


namespace ViewingsApp.Tests
{
    public class AgentTest
    {
        [Test]
        public void agentIsFreeDuringWorkingHours()
        {
            var newAgent = new Agent{StartTime = 9, EndTime = 17};
            var startTime = new DateTime(2020, 7, 22, 10, 0, 0);

            var isFree = newAgent.IsFreeAt(startTime);

            isFree.Should().BeTrue();

        


        }

        [Test]
        public void agentIsNotFreeBeforeWorkingHours()
        {
            var newAgent = new Agent{StartTime = 9, EndTime = 17};
            var startTime = new DateTime(2020, 7, 22, 8, 0, 0);

            var isFree = newAgent.IsFreeAt(startTime);

            isFree.Should().BeFalse();

        


        }

        [Test]
        public void agentIsNotFreeAfterWorkingHours()
        {
            var newAgent = new Agent{StartTime = 9, EndTime = 17};
            var startTime = new DateTime(2020, 7, 22, 18, 0, 0);


            var isFree = newAgent.IsFreeAt(startTime);

            isFree.Should().BeFalse();


        }
    }



}