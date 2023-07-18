using BubberDinner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Domain.MenuAggregator.Events
{
    public record MenuCreated(Menu menu) : IDomainEvent;
}
