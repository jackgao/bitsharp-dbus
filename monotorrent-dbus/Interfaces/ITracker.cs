using System;
using NDesk.DBus;

namespace MonoTorrent.DBus
{
	public delegate void AnnounceHandler ();
	public delegate void ScrapeHandler ();
	public delegate void StateChangedHandler ();
	
	[Interface ("org.monotorrent.tracker")]
	public interface ITracker : IExportable
	{
		event AnnounceHandler AnnounceReceived;

		event ScrapeHandler ScrapeReceived;

		event StateChangedHandler StateChanged;


		// True if the announcing is supported
		bool GetCanAnnounce ();

		// True if scraping is supported
		bool GetCanScrape ();

		// The number of seeds
		int GetComplete ();

		// The number of time the torrent has been downloaded
		int GetDownloaded ();

		// The failure message if the tracker could not be contacted
		string GetFailureMessage ();

		// The number of leeches
		int GetIncomplete ();

		// The warning message (if any)
		string GetWarningMessage ();

		
		// Announce to the tracker
		void Announce();

		// Scrape the tracker
		void Scrape();
	}
}
