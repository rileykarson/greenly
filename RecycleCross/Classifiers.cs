namespace RecycleCross
{
    /// <summary>
    /// Classification arrays used to determine what bin a tag falls into.
    /// </summary>
    public static class Classifiers
    {
        private static string[] blue =
        {
          "plastic",
          "aluminum",
          "steel",
          "tin",
          "can",
          "cans",
          "glass",
          "bottle",
          "bottles",
          "jar",
          "foil",
          "drink cans",
          "coke",
          "pepsi",
          "drink",
          "soft drink",
          "carbonated soft drinks",
          "coca cola",
          "Coca-Cola",
          "Cola",
          "COCA COLA JEANS",
          "Red Bull",
          "blue",
          "doritos",
        };

        private static string[] green =
        {
            "banana",
            "peel",
            "banana peel",
            "fruit",
            "apple",
            "produce",
            "organic",
            "yellow",
        };

        private static string[] grey =
        {
            "newspaper",
            "paper",
            "mail",
            "cartons",
            "cup",
            "coffee cup",
            "cardboard",
            "paper cup",
            "juice cartons",
            "Milk cartons",
            "bubble wrap",
            "starbucks",
            "soylent",
        };

        /// <summary>
        /// Gets the classifier for Blue Bin items.
        /// </summary>
        public static string[] Blue
        {
            get
            {
                return blue;
            }
        }

        /// <summary>
        /// Gets the classifier for Green Bin/Compost items
        /// </summary>
        public static string[] Green
        {
            get
            {
                return green;
            }
        }

        /// <summary>
        /// Gets the classifier for Grey Bin items
        /// </summary>
        public static string[] Grey
        {
            get
            {
                return grey;
            }
        }
    }
}
