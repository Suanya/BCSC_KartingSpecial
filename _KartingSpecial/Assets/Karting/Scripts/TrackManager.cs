using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using System.Linq;


namespace KartGame.Track
{
    /*
    /// <summary>
    /// A Monobehavior to deal with all the time and positions for the racers
    /// </summary>

    public class TrackManager : MonoBehaviour
    {

        [Tooltip("The name of the track in the scene. Used for track time records. Must be unique.")]
        public string trackName;

        [Tooltip("Number of Labs ofh the race.")]
        public int raceLapTotal;

        [Tooltip("All the checkpoints for the track in the order that they should be completed starting with the start/finish line checkpoint")]
        public List<Checkpoint> checkpoints = new List<Checkpoint>();

        [Tooltip("Refrence to an object responsible for repositioning karts")]
        public KartRepositioner kartRepositioner;

        public GhostManager ghostManager;

        bool m_IsRaceRunning;
        Dictionary<IRacer, Checkpoint> m_RacerNextCheckpoints = new Dictionary<IRacer, Checkpoint>(16);
        TrackRecord m_SessionBestLap = TrackRecord.CreatDefault();
        TrackRecord m_SessionBestRace = TrackRecord.CreateDefault();
        TrackRecord m_HistoricalBestLap;
        TrackRecord m_HistoricalBestRace;

        public bool IsRacingRunning => m_IsRaceRunning;

        /// <summary>
        /// Returns the best lap time recorded this session. If no record is found, -1 is returned
        /// </summary>
        public float SessionBestLap
        {
            get
            {
                if (m_SessionBestLap != null && m_SessionBestLap.time < float.PositiveInfinity)
                    return m_SessionBestLap.time;
                return -1f;
            }
        }

        /// <summary>
        /// Returns the best race time recorded this session. If no record is found, -1 is returned
        /// </summary>
        public float SessionBestRace
        {
            get
            {
                if (m_SessionBestRace != null && m_SessionBestRace.time < float.PositiveInfinity)
                    return m_SessionBestRace.time;
                return -1f;
            }
        }

        /// <summary>
        /// Returns the best lap time ever. If no record is found, -1 is returned
        /// </summary>
        public float HistoricalBestLap
        {
            get
            {
                if (m_HistoricalBestLap != null && m_HistoricalBestLap.time < float.PositiveInfinity)
                    return m_HistoricalBestLap.time;
                return -1f;
            }
        }

        /// <summary>
        /// Returns the best race time ever. If no record is found, -1 is returned
        /// </summary>
        public float HistoricalBestRace
        {
            get
            {
                if (m_HistoricalBestRace != null && m_HistoricalBestRace.time < float.PositiveInfinity)
                    return m_HistoricalBestRace.time;
                return -1f;
            }
        }

        private void Awake()
        {
            if (checkpoints.Count < 3)
                Debug.LogWarning("There are currently " + checkpoints.Count + " checkpoints set on the Track Manager. A minimum of 3 is recommended but kert");

            m_HistoricalBestLap = TrackRecord.Load(trackName, 1);
            m_HistoricalBestRace = TrackRecord.Load(trackName, raceLapTotal);

            void OnEnable()
            {
                for(int i = 0; i< checkpoints.Count; i++)
                {
                    checkpoints[i].OnKartHitCheckpoints -= CheckRacerHitCheckpoint;
                }
            }
        }

        private void Start()
        {
            if (checkpoints.Count = 0)
                return;

            Object[] allRacerArray = FindObjectsOfType<Object>.Where(x => x is IRacer).ToArray();

            for (int i = 0; i < allRacerArray.Length; i++)
            {
                IRacer racer = allRacerArray[i] as IRacer;
                m_RacerNextCheckpoints.Add(racer, checkpoints[0]);
                racer.DisableControl();
            }
        }


        /// <summary>
        /// Starts the timers and enables control of all racers
        /// </summary>
        public void StartRace()
        {
            m_IsRaceRunning = true;
            ghostManager.recording = true;
            ghostManager.playing = false;

            foreach (KeyValuePair<IRacer, Checkpoint> racerNextCheckpoint in m_RacerNextCheckpoints)
            {
                racerNextCheckpoint.Key.EnableControl();
                racerNextCheckpoint.Key.UnpauseTimer();
            }
        }


        /// <summary>
        /// Stops the timers and disables control of all racers, also saves the historical records
        /// </summary>
        public void StopRace ()
        {
            m_IsRaceRunning = false;
            ghostManager.recording = false;

            foreach ( KeyValuePair<IRacer, Checkpoint> racerNextCheckpoint in m_RacerNextCheckpoints)
            {
                racerNextCheckpoint.Key.DisableControl();
                racerNextCheckpoint.Key.PauseTimer();

                TrackRecord.Save(m_HistoricalBestLap);
                TrackRecord.Save(m_HistoricalBestRace);

            }
        }

        /*
        private void CheckRacerHitCheckpoint (IRacer racer, Checkpoint checkpoint)
        */

}

