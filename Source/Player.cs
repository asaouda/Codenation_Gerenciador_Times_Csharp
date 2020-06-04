using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Player
    {
        /*
            - `long` `id`* Identificador do Jogador
            - `long` `teamId`* Identificador do time
            - `string` `name`* Nome do Jogador
            - `DateTime` `birthDate`* Data de nascimento do Jogador
            - `int` `skillLevel`* Nível de habilidade do jogador (0 a 100)
            - `decimal` `salary`* Salário do jogador
         */
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }

        public Player(long id,long teamId, string name, DateTime birthDate,int skillLevel, decimal salary)
        {
            Id = id;
            TeamId = teamId;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
        }
    }
}
