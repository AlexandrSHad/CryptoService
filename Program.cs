using System;

namespace CryptoHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Sign();

            Verify();
        }

        private static void Sign()
        {
            var crService = new CryptoService();
            var dsHelper = new DataStringHelper();

            var dataString = dsHelper.GetDataStringForSign(
                merchantId: "1755156",
                terminalId: "E7883166",
                purchaseTime: "181102091010",
                orderId: "VHS1036009",
                currency: "980",
                totalAmount: "100",
                sessionData: "584sds565hgj76GGjh6756248"
            );

            var signature = crService.GetSign(dataString);

            Console.WriteLine("Data string:");
            Console.WriteLine(dataString);
            Console.WriteLine();
            Console.WriteLine("Signature:");
            Console.WriteLine(signature);
        }

        private static void Verify()
        {
            var crService = new CryptoService();
            var dsHelper = new DataStringHelper();

            var dataString = dsHelper.GetDataStringForVerify(
                merchantId: "1755156",
                terminalId: "E7883166",
                purchaseTime: "181102091010",
                orderId: "VHS1036009",
                xId: "18110216-400388",
                currency: "980",
                totalAmount: "100",
                sessionData: "584sds565hgj76GGjh6756248",
                tranCode: "405",
                approvalCode: ""
            );

            var signature = "X43e6NH1L7V6FJK+BdPKvvVrHAYfm7zc3qIWI8ho5ezIZ0GxP1TmIpUxFBeVl+rDsUCE1bE3PHh2m8NWJ60mGOaP0vcyYQf/E+D1Lz1Cun/vOZmcPq5hWkbx6uoJm0mJlrkM07f3LXDGHUF+04pbB9zqa/M/nIcwvUMSLiQ04yk=";

            var result = crService.Verify(dataString, signature);

            Console.WriteLine("Signature verified: " + result);
        }
    }
}
