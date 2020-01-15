using System;
using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
	    private readonly List<ISong> songs;
	    private readonly List<IPerformer> performers;

	    public Stage()
	    {
	        this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
	    }

	    public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

	    public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

	    public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

	    public IPerformer GetPerformer(string name)
	    {
	        IPerformer performer = this.performers.FirstOrDefault(x => x.Name == name);

	        if (performer == null)
	        {
	            throw new InvalidOperationException("Invalid performer provided");
            }

	        return performer;
	    }

	    public ISong GetSong(string name)
	    {
	        ISong song = this.songs.FirstOrDefault(x => x.Name == name);

	        if (song == null)
	        {
	            throw new InvalidOperationException("Invalid song provided");
	        }

	        return song;
        }

	    public ISet GetSet(string name)
	    {
	        ISet set = this.sets.FirstOrDefault(x => x.Name == name);

	        if (set == null)
	        {
	            throw new InvalidOperationException("Invalid set provided");
            }

	        return set;
        }

	    public void AddPerformer(IPerformer performer)
	    {
	        this.performers.Add(performer);
	    }

	    public void AddSong(ISong song)
	    {
	        this.songs.Add(song);
	    }

	    public void AddSet(ISet set)
	    {
            this.sets.Add(set);
	    }

	    public bool HasPerformer(string name)
	    {
	        return this.performers.Any(x => x.Name == name);
	    }

	    public bool HasSong(string name)
	    {
	        return this.songs.Any(x => x.Name == name);
	    }

	    public bool HasSet(string name)
	    {
	        return this.sets.Any(x => x.Name == name);
	    }
	}
}
