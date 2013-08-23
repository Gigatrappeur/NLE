using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Loader
{
    public interface ILoader
    {
        bool Load(Words dico);
        bool UnLoad();

        // doit gérer les interactions entre le dictionnaire et son support de stockage

    }
}
