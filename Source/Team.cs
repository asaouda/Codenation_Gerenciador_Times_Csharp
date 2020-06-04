using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Team
    {
        /*
         * Realiza a inclusão de um novo time.

            - `long` `id`* Identificador do time
            - `string` `name`* Nome do Time
            - `DateTime` `dataCriacao`* Data de criação do time
            - `string` `corUniformePrincipal`* Cor do uniforme principal do time
            - `string` `corUniformeSecundario`* Cor do uniforme secundário do time
        */

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }
        public Player PlayerId { get; set; }
        
        public Team(long id,string name,DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Id = id;
            Name = name;
            CreateDate = createDate;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;
        }
    }
}
