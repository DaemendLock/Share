public class TaskTwelve {
    private const uint GoldCostOfGuildTokens = 1;
    private const uint GoldCostOfStamina = 1;

    private const byte ExitCode = 0;
    private const byte GoldId = 1;
    private const byte StaminaId = 2;
    private const byte GuildTokensId = 3;

    private const uint GoldStartValue = 0;
    private const uint StaminaStartValue = 0;
    private const uint GuildTokensStartVakue = 100;

    public unsafe static void Main(String[] args)
    {
        uint gold = GoldStartValue;
        uint stamina = StaminaStartValue;
        uint guildTokens = GuildTokensStartVakue;

        uint* convertFrom;
        uint* convertTo;
        
        do
        {
            Console.WriteLine($"Balance: Gold - {gold}, Stamina - {stamina}, Guild tokens - {guildTokens}. Write id of currency to convert from. <{GoldId} - gold, {StaminaId} - stamina, {GuildTokensId} - guild tokens>. Use {ExitCode} to exit");
            switch (Convert.ToByte(Console.ReadLine()))
            {
                case ExitCode:
                    convertFrom = null;
                    continue;
                case GoldId:
                    convertFrom = &gold;
                    break;
                case StaminaId:
                    convertFrom = &stamina;
                    break;
                case GuildTokensId:
                    convertFrom = &guildTokens;
                    break;
                default:
                    throw new Exception("Failed to identify currency Id");
            }

            Console.WriteLine("Choose currency to convert to:");
            
            switch (Convert.ToByte(Console.ReadLine()))
            {
                case GoldId:
                    convertTo = &gold;
                    break;
                case StaminaId:
                    convertTo = &stamina;
                    break;
                case GuildTokensId:
                    convertTo = &guildTokens;
                    break;
                default:
                    throw new Exception("Failed to identify currency Id");
            }

            if (convertTo == convertFrom)
            {
                Console.WriteLine("Can't convert currency to itself.");
                continue;
            }
            
            Console.WriteLine("Write how much currency you want to convert:");
            ConvertCurrency(convertFrom, convertTo, Convert.ToUInt32(Console.ReadLine()));

        } while (convertFrom != null);
    }

    private static unsafe void ConvertCurrency(uint* convertFrom, uint* converTo, uint currnecyValueToConvert)
    {
        if (currnecyValueToConvert > *convertFrom)
        {
            throw new Exception("Failed to convert currency. Not enough");
        }
        
        *convertFrom -= currnecyValueToConvert;
        *converTo += currnecyValueToConvert;
    }
}
