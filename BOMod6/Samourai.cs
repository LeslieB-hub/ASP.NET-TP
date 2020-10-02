

using System.Collections.Generic;

namespace BOMod6
{
    public class Samourai : IdKey
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartials { get; set; }
        // pour avoir un count à 0 initialiser la liste: = new List<ArtMartial>();
        public int Potentiel { get => getPotentiel(); }

        public int getPotentiel()
        {
            int potentiel;
            int nbArtMartial;
            int degats;
            //(this.Force + this.Arme.Degats) * (this.ArtMartials.Count + 1);
            if (this.Arme == null)
            {
                degats = 0;
            }
            else
            {
                degats = this.Arme.Degats;
            }
            if (this.ArtMartials == null)
            {
                nbArtMartial = 0;               
            }
            else
            {
                nbArtMartial = this.ArtMartials.Count;
            }
            potentiel = (this.Force + degats) * (nbArtMartial + 1);
            
            return potentiel;
        }

    }
}
