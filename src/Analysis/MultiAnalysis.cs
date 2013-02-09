﻿using Cluster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analysis
{
  public class MultiAnalysis
  {
    #region Properties

    /// <summary>
    /// The multi collection of events
    /// </summary>
    public EventCollection Events { get; protected set; }

    /// <summary>
    /// The DBSCAN object that performs the multi clustering.
    /// </summary>
    protected DBSCAN DBscan;

    #endregion

    #region Constructor

    /// <summary>
    /// Primary Constructor
    /// </summary>
    public MultiAnalysis()
    {
      Events = new EventCollection();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// This method will add a given event to the list of events. Any previous 
    /// clustering information will be removed.
    /// </summary>
    /// <param name="evt">The event to be added</param>
    public void Add(Event evt)
    {
      // Remove any previous clustering data
      evt.Coordinate.ClearClusterData();
      // Add the event to the EventCollection
      Events.Add(evt);
    }

    /// <summary>
    /// This method will add an exisitng EventCollection to the EventCollection 
    /// object within this class. Any previous clustering information will be 
    /// removed.
    /// </summary>
    /// <param name="collection">The EventCollection to be added</param>
    public void AddRange(EventCollection collection)
    {
      // Remove any previous clustering data
      collection.ClearAllClusterData();
      // Add the events to the EventCollection
      Events.AddRange(collection);
    }

    /// <summary>
    /// This method will add a number of exisitng EventCollections being held 
    /// within a list to the EventCollection object within this class. Any 
    /// previous clustering information will be removed.
    /// </summary>
    /// <param name="collections">A list ov EventCollections</param>
    public void AddRange(List<EventCollection> collections)
    {
      foreach (EventCollection collection in collections)
      {
        AddRange(collection);
      }
    }

    /// <summary>
    /// This method will initalise the clustering algorithm, in order to cluster
    /// the data set held within this object.
    /// </summary>
    public void Cluster()
    {
      // Cluster the data
      DBscan = new DBSCAN(Events);
      DBscan.Analyse();
    }

    #endregion
  }
}