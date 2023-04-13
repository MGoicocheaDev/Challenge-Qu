using app_lib.Matrix;

namespace cmd_app_matrix_test
{
    public class WordFinderTest
    {
        private IWordFinder _wordFinder_not_exceded_max;

        [SetUp]
        public void Setup()
        {
            var matrix = new List<string>
            {
                "hello",
                "jrldh",
                "odozi",
                "bdooc",
                "mrkpq"
            };
            _wordFinder_not_exceded_max = new WordFinder(matrix);
        }

        [Test]
        public void FindWord_Should_Not_Exceded_Max_Matrix()
        {
            List<string> words = new List<string>()
            {
                "hello",
                "job",
                "word",
                "world",
                "look",
                "find",
                "ice",
                "host",
                "ghost",
                "hi"
            };

            List<string> word_expected = new List<string>()
            {
                "hello",
                "job",
                "look",
                "hi"
            };

            var result = _wordFinder_not_exceded_max.Find(words).ToList();

            CollectionAssert.AreEqual(word_expected, result);
        }

        [TestCase(80,64)]
        [TestCase(64,80)]
        [Test]
        public void FindWord_should_Exceded_Max_limits(int row, int colum)
        {
            Assert.Throws<ArgumentException>(
                () => new WordFinder(CreateMatrix(row, colum)));

        }

        [Test]
        public void FindWord_Should_Use_Max_Limit()
        {
            List<string> wordMatrix = new List<string>
            {
                "SYCNSZZKBEGNERainbowBAUWUZSLUOLLNNJOOTYVKNightUMVHZZMEPLUDTTRWIP",
                "CPDPXNZVWUUJEDWVPJSkyOVARSIDWIDHTRRKKTJQWYEAKFMUKBPBTCXZJXCCCWQT",
                "MCCALQTDFBlueLVBDRVDVDZBRXJANHEXFTSZUYANGEOZGZHQGOKMJQOZXQDFKVRU",
                "NPCOJIFWinterLSKTNVSKZRJVKOAUKHQYBNZHKRXAAXMIUniverNightghtHORBF",
                "LOJWinterNJBRDSCGFSSXBZSZHJTOGREZOFishKWGAQPEFZBlueQEAEggMZLMODX",
                "PJMWNOrbitVUGJCAWDPLFEEIEYXCZRNJLZEggMKXKKELIBBYTLVIVSUSJYJMYEVL",
                "GHJROOKSDJIDUICGWLTQZCVGOKRBSADSRMGGKQZYGPFOPETPPSVWJEGCWBUAHLKJ",
                "ZJNLUSROrbitJOJOGUGDISNJMMRDPFYYBZBOHOrbitWBGYJZMOHAHDQWCNULNSRS",
                "ECYGBVJXADZOKCECDWinterLSushiRQFKTAXQOLWJFLWLOQBHCJSWATTVCVZADFL",
                "NUQPKXVDGAYVMBEPKJFEBUJVFKOQJKZCFBDGXSGCVIYECKWZHWinterhtUFMFHFK",
                "FRZHHXBKZHQWMICGPFYAIFHEKTSKMUMSFXEggRNRYDXTLZOXVJIAYFBHCDLRLGNM",
                "YAMJHCYRCXRBZIGKWBOZRRJJMZOIEYRRBNBirdJAKYPULMFCRPXTSmileMRXMEYS",
                "IYHBOQPDMUUXZYQPBPUIZOKOANWJNGQOEggWATKLNOZWRQBWWMBNKGKWIIYHEggO",
                "RHJRainbowNYRNOJUAOUNJFJXVBNHWRPMQRJTRJRainbowXJYQCOXCPPDFDLHNJN",
                "SmileLDNODBWGBXCREOSEHKIRJYOELIGLPYUTLSTTPJNightQIPHHINVGAppleOX",
                "GTCKQNCPAQHXQNVHEFKIMAWWHSushiRYJSCUYSEYARPJRLXMZXLZQCWKBCJGPSWZ",
                "MENVZSLKNLGBSVQKMBGIKORDOBJVCAEOVGTWBKZJEggLQZGQBIXFHSFJHNightMZ",
                "LLXLYHAMCBHRLSAVVNWMWOSNUJGUCFAJQHTIKXOTPGHBMKYFCXIJJMVOrbitbowN",
                "LOWCJDRTPELKUBCKLRRZTXGLZDSYNHLXVSHNJWKQXAUIUSLSPGDNIDASmileTSAW",
                "WMGRVenuswKMTQXJQAHAKTSSunshineNISkySRainbowMXQQSMVWOLWSJISkyFCO",
                "ZRTMRPTPNSDOTZPYUQWYKDTWYIARJXOIYPOYULXJHHJDVTPBJLRNHQEQEFAWZRQL",
                "UADMHWYDDEBUCGOMMNFVFEGNAJITLWGVPCUSEBEHKTBYASKALZABSNKKDOZQGXJY",
                "MFATIFishNHJKPOVSAXBJCQPGBBSVNWGJQHCMQBEJYFWIICFKLCUUnivSushiCSE",
                "AXBOSWNRDRXMEUHBASXZJYRKRTVBPBZHAFUNIUSWENMMAPPJAFLFishTYUHZEDBN",
                "TRSEXMYTVFPCHENIRULPJTMGCAOFBRXSCLABlueEXYNCQEBlueKBMUSushiQHTPK",
                "ULQGVBMMMKRHWEPRainbowOHXGEBWKTPJUSMICWWYSROANZZDIHGQYRainbowXLJ",
                "NXCDNXICFDBZFGMNIUHVAUVMFBBOIWJLFBELJZVOMJLGWSushiowKZZWBSTUVBGD",
                "MXIDZRECFVQDCQOXTWRRQXAHASQCPSmileQPBBPIVDNVDEFWHGBCAZKPAQGGZBOQ",
                "KKFOYZRKXSHKSVLMQMEEJMGTUNFJGPBWWEXRMUPXJAIHJGOFBFBPLYXZKNOSUSAI",
                "NFPYIZNUJDUFGSKFLDOJBUFBSKDRainbowPTQKSJNIERFUZUVEUVHGVPHMOJBNNS",
                "IPDKAGVQDKVWQBirdGFPJVWOJLNISXBANTLUBPURZIPHPMFNZHIAFCZBOrbitOCC",
                "UFEUEVWTCPNSOZJOFBBASYHUTRainbowEDGYGJGKMHXYNIUYFXUniverseJIBWHB",
                "UJRUniverseBLFKRSUDBAWinterFMTSZCWKLINYAVQWWAAKXVRFPFQSmileZGWBI",
                "PRainbowBCKDDKGYRWGSXEZMNTCJKLGERUEWSRBPFAATMFDOYQJWWSEAVDJOXAKF",
                "BXCTFNIJLTYONXVGHECIVJWRDXLDZAOIUXUZMJWBUOUNXBLRMPERLXONRXIDWPBK",
                "UUKJPZQSECSPSNJKZAGQSZKWVTLQBSMATEggNYPXEGOQNRUWLMEWEUPLRTQHOAEP",
                "UURTUMGDOEDQVXBNJQGFPQZBJGXAMZLPRNEZRHECZACGGHEQRTSpringYMLSYFDO",
                "TJHYHKGYNDSZVenusQATAVWMKOPEZDRLFGWXEREHDAPFFMYYMBXNightQXSDIWLT",
                "RIEHWRIWinterQDTSNYCHMLQKCZHOJIHIANBUKHBSGKGFYQISNightBVKVLETAON",
                "FRBTUYHSMIZDVFEJZRTKKDAXCIXJMBSushiNWRKMCCHTXPJPZHBEZFAPMCFSUUWN",
                "ZEIAFSkyDCBJIPGSAUUNKSkyGRIHULZWZUEEFFEIDEMTYSHLKHBQLCIKLVNCDYJN",
                "HGUVEGLJSmileLBJJLQKJXPQMDZUTGOButterflyFKHRainbowQWNOSFVCBMERKJ",
                "FLRATKAZOOTAWWNBBVLLLACKXYWTSSQYITQBlueYGQTISGZICZOVXBCCMYOVEUZA",
                "JUEWinterUBKGTZGMSWTBNGSUAQHTPFTYCAJCQWinterCXWSSKJYNBYMISZHFJLG",
                "WUFVWIZCVSXMVCLVGMNHGSFDZRREMIQZELACAABBAFREZYOALBTDAYYBEAESAYIQ",
                "EMIQEWRNEUKXKCZUniverseZBMSBSkyDIRELHCSBJIGXFRRQXZZGMUHKCSmileAL",
                "WVXHWNESUYVFXHBLNCBCKQDSUPUJEHDFTNZIFPKLORBGJZILIMABlueJAYOrbitY",
                "KOMTXIQBSQSBRGGOZZGMHDLYKSMPENSLYVJHCMZRJKSCQLJNNWVMELUAQWNUPVIR",
                "NZJJFUSXYGWNCTWYXXYOZLIXEUNMXFALJUYCFBRGJXYKVRITESushiIONBDYXTDT",
                "OAFKRXFRZJRainbowQCZHGTHWEOCENLSEHRRKXBUDQSBKYKJDWDMXHVEBISBTCDI",
                "LTAppleiverRainbowNightQLBMBSRYCBZXRBQIKRainbowKAIAKKQXRKPSIVWBJ",
                "SmileIKMLJGNPRYMLIGTABOrbitHXZQXSmileKFPQXOIVEZUDBCZNXRWinterkyX",
                "AFXZZZRDKDVVZYJMUJWFHALVDMIWJSSWOYVPPLighthouseDKQRKYLMXANEVYHLX",
                "HJKGFVITXXHIAHWPKKWNTNIBZMRQKFGQNZBLBKGGNVLQNHFTKJWVMQLHLQKCTEWX",
                "ZUVNSQEMGMANSUVYVUGXYOEXEXJYYHPLCIMIDMSUniverseFBYGDOKVISPSALCUB",
                "UCCUIYHFRQPQELOMUHKPWBluePOTOUVIDNJGFTJCJBJVMRGJBBZNJHYHETKDCIBY",
                "JYPDZTVSVVXBBEHSEHYQPZCINTKUZIAYPDMXMMBKIXWJEXVPOUGBWBAppleQRTPP",
                "OTDSUICWAZASNMSmileMFQKNightZEKNCBCTOXENUniUniverseKZGUNLULDFFNP",
                "RainbowSBSCFZFWJCMCOUGCBZQCIKOOUTPQCINDPAGAZGDMYOEVDXMOVCHRFTWJU",
                "POPGVBOQVLHWNFLPPLUFWIYCCUKLDVMREMLXSJFZDGIVFNAOREXHXLPEYGMQIKDV",
                "LHJMNVRYNHEFJONERainbowNIPHTZFQCDHLDGTBBWQKIYVJUUSCMYIKMSpringNJ",
                "EMRCTUSSKBFZWSXHGRPLYYEJXFXVenusHYCLORKWWVFELJTENGHCDHSVAIPRIUTA",
                "RGWUMRSTXLHZCVenusinbowBOSXICETEggGHMLGPKHJEDNPCSWPIMFishOVGGABY",
                "TIBDPTMVORBACPSQESEPGHDBHHVUXZQLPZWTCFMEMWQYNPLUniverseAFTALHUWN"
            };
            IWordFinder wordFinder_limit = new WordFinder(wordMatrix);
            List<string> words = new List<string>()
            {
                "Apple", "Happy", "Time","Dog","Summer","Blue","Night","Water",
                "Orange","Light", "Green", "Bird","Music","Sun", "Love", "Moon",
                "Fish", "Snow", "Heart", "Fire", "House", "Star", "Wind", "Tree",
                "Ocean","Smile", "Butterfly", "Rock", "River", "Train", "Garden",
                "Rainbow","Moonlight", "Sunshine", "Lighthouse", "Horizon",
                "Adventure", "Compass", "Autumn","Mountain","Thunder","Sand",
                "Beach", "Desert","Island","Journey","Sky", "Thunderstorm",
                "Tornado", "Hurricane","Lightning","Rain","Snowflake","Snowstorm",
                "Spring","Storm","Sunset","Thunderbolt", "Weather", "Windy",
                "Winter", "Astrology","Astronomy","Clouds","Comet","Eclipse",
                "Galaxy","Meteor","Nebula","Orbit","Satellite","Solar","Spacecraft",
                "Stars","Universe","Venus","Breakfast","Cheese","Chicken","Coffee",
                "Dinner","Egg","Fruit","Hamburger","Hotdog","Ice cream","Meat",
                "Pizza","Salad","Sandwich","Soup","Steak","Sushi","Vegetables",
                "Guitarra","Fresa","Silla","Nariz","Calle","Mono"
            };

            var result = wordFinder_limit.Find(words);

            foreach(var word in result)
            {
                Console.WriteLine(word);
            }

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.LessThanOrEqualTo(10));
        }

        #region Private Method
        private List<string> CreateMatrix(int numRows, int numCols)
        {
            var matrix = new List<string>();
            var random = new Random();
            var chars = Enumerable.Range('a', 26).Select(c => (char)c).ToArray();
            for (int i = 0; i < numRows; i++)
            {
                var row = new char[numCols];
                for (int j = 0; j < numCols; j++)
                {
                    row[j] = chars[random.Next(chars.Length)];
                }
                matrix.Add(new string(row));
            }
            return matrix;
        }
        
        
        #endregion
    }
}