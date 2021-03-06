// PeerAdapter.cs created with MonoDevelop
// User: alan at 15:58 05/06/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using MonoTorrent.Client;
using MonoTorrent.Client.Encryption;

using NDesk.DBus;
using System.Collections.Generic;

namespace MonoTorrent.DBus
{
	public struct PeerAdapter : IPeer
	{
		private PeerId id;
		
		public PeerAdapter(PeerId id)
		{
			this.id = id;
		}
		
		public bool AmChoking {
			get { return id.AmChoking; }
		}

		public bool AmInterested {
			get { return id.AmInterested; }
		}

		public int AmRequestingPiecesCount {
			get { return id.AmRequestingPiecesCount; }
		}

		public EncryptionTypes ActiveEncryption {
			get
			{
				if (id.Encryptor is RC4)
					return EncryptionTypes.RC4Full;
				if (id.Encryptor is PlainTextEncryption)
					return EncryptionTypes.PlainText;
				return EncryptionTypes.RC4Header;
			}
		}

		public int HashFails {
			get { return id.HashFails; }
		}
		
		public PeerId Id {
			get { return id; }
		}

		public bool IsChoking {
			get { return id.IsChoking; }
		}

		public bool IsInterested {
			get { return id.IsInterested; }
		}

		public int IsRequestingPiecesCount {
			get { return id.IsRequestingPiecesCount; }
		}

		public bool IsSeeder {
			get { return id.IsSeeder; }
		}

		public bool IsConnected {
			get { return id.IsConnected; }
		}
		
		public string PeerId {
			get { return id.PeerID; }
		}

		public int PiecesSent {
			get { return id.PiecesSent; }
		}

		public bool SupportsFastPeer {
			get { return id.SupportsFastPeer; }
		}
		
		public string Uri {
			get { return id.Uri.ToString(); }
		}

		
		#region IPeer implementation 
		
		bool IPeer.GetAmChoking ()
		{
			return AmChoking;
		}
		
		bool IPeer.GetAmInterested ()
		{
			return AmInterested;
		}
		
		int IPeer.GetAmRequestingPiecesCount ()
		{
			return AmRequestingPiecesCount;
		}
		
		EncryptionTypes IPeer.GetActiveEncryption ()
		{
			return ActiveEncryption;
		}
		
		int IPeer.GetHashFails ()
		{
			return HashFails;
		}
		
		bool IPeer.GetIsChoking ()
		{
			return IsChoking;;
		}
		
		bool IPeer.GetIsInterested ()
		{
			return IsInterested;
		}
		
		int IPeer.GetIsRequestingPiecesCount ()
		{
			return IsRequestingPiecesCount;
		}
		
		bool IPeer.GetIsSeeder ()
		{
			return IsSeeder;
		}
		
		bool IPeer.GetIsConnected ()
		{
			return IsConnected;
		}
		
		string IPeer.GetPeerId ()
		{
			return PeerId;
		}
		
		int IPeer.GetPiecesSent ()
		{
			return PiecesSent;
		}
		
		bool IPeer.GetSupportsFastPeer ()
		{
			return SupportsFastPeer;
		}
		
		string IPeer.GetUri ()
		{
			return Uri;
		}
		
		#endregion 
		

		internal static IPeer[] Adapt(List<PeerId> list)
		{
			return list.ConvertAll<IPeer>(delegate(PeerId p) {
				return new PeerAdapter(p);
			}).ToArray();
		}
	}
}
