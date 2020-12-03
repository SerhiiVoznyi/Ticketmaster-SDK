namespace Ticketmaster.Core
{
    public static class Markets
    {
        public enum USA
        {
            Birmingham_Amd_More = 1,
            Charlotte = 2,
            Chicagoland_And_Northern_IL = 3,
            Cincinnati_And_Dayton = 4,
            Dallas_Fort_Worth_And_More = 5,
            Denver_And_More = 6,
            Detroit_Toledo_And_More = 7,
            El_Paso_And_New_Mexico = 8,
            Grand_Rapids_And_More = 9,
            Greater_Atlanta_Area = 10,
            Greater_Boston_Area = 11,
            Cleveland_Youngstown_And_More = 12,
            Greater_Columbus_Area = 13,
            Greater_Las_Vegas_Area = 14,
            Greater_Miami_Area = 15,
            Minneapolis_Paul_And_More = 16,
            Greater_Orlando_Area = 17,
            Greater_Philadelphia_Area = 18,
            Greater_Pittsburgh_Area = 19,
            Greater_San_Diego_Area = 20,
            Greater_Tampa_Area = 21,
            Houston_And_More = 22,
            Indianapolis_And_More = 23,
            Iowa = 24,
            Jacksonville_And_More = 25,
            Kansas_City_And_More = 26,
            Greater_Los_Angeles_Area = 27,
            Louisville_And_Lexington = 28,
            Memphis_Little_Rock_And_More = 29,
            Milwaukee_And_WI = 30,
            Nashville_Knoxville_And_More = 31,
            New_England = 33,
            New_Orleans_And_More = 34,
            New_York_Tri_State_Area = 35,
            Phoenix_And_Tucson = 36,
            Portland_And_More = 37,
            Raleigh_And_Durham = 38,
            Saint_Louis_And_More = 39,
            San_Antonio_And_Austin = 40,
            N_California_N_Nevada = 41,
            Greater_Seattle_Area = 42,
            North_And_South_Dakota = 43,
            Upstate_New_York = 44,
            Utah_And_Montana = 45,
            Virginia = 46,
            Washington_DC_And_Maryland = 47,
            West_Virginia = 48,
            Hawaii = 49,
            Alaska = 50,
            Nebraska = 52,
            Springfield = 53,
            Central_Illinois = 54,
            Northern_New_Jersey = 55,
            South_Carolina = 121,
            South_Texas = 122,
            Beaumont = 123,
            Connecticut = 124,
            Oklahoma = 125
        }

        public static int GetMarketId(this USA value)
        {
            return (int)value;
        }

        public enum Canada
        {
            Toronto_Hamilton_And_Area = 102,
            Ottawa_And_Eastern_Ontario = 103,
            Manitoba = 106,
            Edmonton_And_Northern_Alberta = 107,
            Calgary_And_Southern_Alberta = 108,
            B_C_Interior = 110,
            Vancouver_And_Area = 111,
            Saskatchewan = 112,
            Montreal_And_Area = 120
        }

        public static int GetMarketId(this Canada value)
        {
            return (int)value;
        }

        public enum Europe
        {
            UK_London = 202,
            UK_South = 203,
            UK_Midlands_And_Central = 204,
            UK_Wales_And_North_West = 205,
            UK_North_And_North_East = 206,
            Scotland = 207,
            Ireland = 208,
            Northern_Ireland = 209,
            Germany = 210,
            Netherlands = 211,
            Sweden = 500,
            Spain = 501,
            Spain_Barcelona = 502,
            Spain_Madrid = 503,
            Turkey = 600
        }

        public static int GetMarketId(this Europe value)
        {
            return (int)value;
        }

        public enum AustraliaAndNewZealand
        {
            New_South_Wales_Australian_Capital_Territory = 302,
            Queensland = 303,
            Western_Australi = 304,
            Victoria_Tasmania = 305,
            Western_Australia = 306,
            North_Island = 351,
            South_Island = 352
        }

        public static int GetMarketId(this AustraliaAndNewZealand value)
        {
            return (int)value;
        }

        public enum Mexico
        {
            Mexico_City_And_Metropolitan_Area = 402,
            Monterrey = 403,
            Guadalajara = 404
        }

        public static int GetMarketId(this Mexico value)
        {
            return (int)value;
        }
    }
}
