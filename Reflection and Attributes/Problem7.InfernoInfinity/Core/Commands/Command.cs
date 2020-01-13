using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IGemFactory gemFactory;
        private IRepository repository;
        private IWeaponFactory weaponFactory;

        protected Command(string[] data, IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory)
        {
            this.data = data;
            this.GemFactory = gemFactory;
            this.Repository = repository;
            this.WeaponFactory = weaponFactory;
        }

        protected string[] Data => this.data;

        protected IGemFactory GemFactory
        {
            get => this.gemFactory;
            private set => this.gemFactory = value;
        }

        protected IRepository Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        protected IWeaponFactory WeaponFactory
        {
            get => this.weaponFactory;
            private set => this.weaponFactory = value;
        }

        public abstract void Execute();
    }
}
