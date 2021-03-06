﻿using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttribute;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository unitRepository;

        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.unitRepository = repository;
            this.unitFactory = unitFactory;
        }

        protected IRepository Repository
        {
            get { return this.unitRepository; }
            private set { this.unitRepository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            private set { this.unitFactory = value; }
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
