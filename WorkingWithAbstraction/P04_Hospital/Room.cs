using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        public Room(int id)
        {
            this.Id = id;
            this.Patients = new List<Patient>();
        }

        public int Id { get; private set; }

        public List<Patient> Patients { get; private set; }

        public void AddPatient(Patient patient)
        {
            if (this.Patients.Count >= 3)
            {
                throw new Exception();
            }

            this.Patients.Add(patient);
        }
    }
}
