namespace Problem8.MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
