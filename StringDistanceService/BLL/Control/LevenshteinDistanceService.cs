﻿using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BLL.Control
{
    class LevenshteinDistanceService : IDistanceService
    {

        public double getDistance(string first, string second)
        {
            int distance = LevenshteinDistance(first, second);
            return distance;
        }

        public int LevenshteinDistance(string first, string second)
        {
            if (String.IsNullOrEmpty(first))
                return second.Length;
            if (String.IsNullOrEmpty(second))
                return first.Length;

            int bothFirstCharactersAreTheSame = (first[0] != second[0]) ? 1 : 0;
            return new int[]
            {
                LevenshteinDistance(first[1..], second[1..]) + bothFirstCharactersAreTheSame,
                LevenshteinDistance(first[1..], second) + 1,
                LevenshteinDistance(first, second[1..]) + 1
            }.Min();
        }
    }
}
