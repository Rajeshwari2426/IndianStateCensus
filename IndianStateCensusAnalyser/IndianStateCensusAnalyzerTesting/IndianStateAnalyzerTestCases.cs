using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;

namespace IndianStateCensusAnalyzerTesting
{
    [TestClass]
    public class IndianStateAnalyzerTestCases
    {
        //UC2 - File paths for indian state codes
        string statCodeFilePath = @"C:\Users\rajar\source\repos\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\rajar\source\repos\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongFileNameIndiaStateCode.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\rajar\source\repos\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\rajar\source\repos\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\rajar\source\repos\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";

        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateCodeRecords;
        [TestInitialize]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            // stateRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();

        }
            //TC 2.1 Given correct path To ensure number of records matches
            [TestMethod]
            [TestCategory("Indian State Codes")]
            public void GivenStateCodesCsvReturnStateRecords()
            {
                int expected = 37;
                stateCodeRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, statCodeFilePath, stateCodeHeader);
                Assert.AreEqual(expected, stateCodeRecords.Count);
            }

            //TC 2.2 Given incorrect file should return custom exception - File not found
            [TestMethod]
            [TestCategory("Indian State Codes")]
            public void GivenStateCodesWrongFileReturnCustomException()
            {
                var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeader));
                Assert.AreEqual(expected, customException.exception);
            }

            //TC 2.3 Given correct path but incorrect file type should return custom exception - Invalid file type
            [TestMethod]
            [TestCategory("Indian State Codes")]
            public void GivenStateCodesWrongFileTypeReturnCustomException()
            {
                var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeader));
                Assert.AreEqual(expected, customException.exception);
            }

            //TC 2.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
            [TestMethod]
            [TestCategory("Indian State Codes")]
            public void GivenStateCodesWrongDelimiterReturnCustomException()
            {
                var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeader));
                Assert.AreEqual(expected, customException.exception);
            }

            //TC 2.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
            [TestMethod]
            [TestCategory("Indian State Codes")]
            public void GivenStateCodesWrongHeaderReturnCustomException()
            {
                var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeader));
                Assert.AreEqual(expected, customException.exception);
            }

        
    } 

}
