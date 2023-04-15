public class TaskTwelve
{
    public static void Main(String[] args)
    {
        int goldStartValue = 0;
        int staminaStartValue = 0;
        int guildTokensStartVakue = 100;

        int staminaGoldCost = 2;
        int guildTokensGoldCost = 3;

        const string ExitCode = "0";
        const string GoldId = "1";
        const string StaminaId = "2";
        const string GuildTokensId = "3";

        int gold = goldStartValue;
        int stamina = staminaStartValue;
        int guildTokens = guildTokensStartVakue;

        string convertFrom;
        string convertTo;
        int preferedConvertValue;
        int actualConvertValue;

        do
        {
            Console.WriteLine($"Balance: Gold - {gold}, Stamina - {stamina}, Guild tokens - {guildTokens}. Write id of currency to convert from. <{GoldId} - gold, {StaminaId} - stamina, {GuildTokensId} - guild tokens>. Use {ExitCode} to exit");
            convertFrom = Console.ReadLine();

            if (convertFrom.Equals(ExitCode))
            {
                continue;
            }

            Console.WriteLine("Write currency to convert to:");
            convertTo = Console.ReadLine();
            Console.WriteLine("How much you want to convert?");
            preferedConvertValue = Convert.ToInt32(Console.ReadLine());

            switch (convertFrom)
            {
                case GoldId:
                    
                    if (convertTo.Equals(StaminaId))
                    {
                        actualConvertValue = preferedConvertValue / staminaGoldCost;
                        stamina += actualConvertValue;
                        gold -= actualConvertValue * staminaGoldCost;
                    } else if (convertTo.Equals(GuildTokensId))
                    {
                        actualConvertValue = preferedConvertValue / guildTokensGoldCost;
                        guildTokens += actualConvertValue;
                        gold -= actualConvertValue * guildTokensGoldCost;
                    } else
                    {
                        continue;
                    }

                    break;
                    
                case StaminaId:

                    if (convertTo.Equals(GoldId))
                    {
                        actualConvertValue = preferedConvertValue * staminaGoldCost;
                        gold += actualConvertValue;
                        stamina -= preferedConvertValue;
                    } else if (convertTo.Equals(GuildTokensId))
                    {
                        actualConvertValue = preferedConvertValue * staminaGoldCost / guildTokensGoldCost;
                        guildTokens += actualConvertValue;
                        stamina -= actualConvertValue * guildTokensGoldCost / staminaGoldCost;
                    } else
                    {
                        continue;
                    }

                    stamina -= preferedConvertValue;
                    break;
                    
                case GuildTokensId:

                    if (convertTo.Equals(GoldId))
                    {
                        actualConvertValue = preferedConvertValue * guildTokensGoldCost;
                        gold += actualConvertValue;
                        guildTokens -= preferedConvertValue;
                    } else if (convertTo.Equals(StaminaId))
                    {
                        actualConvertValue = preferedConvertValue * guildTokensGoldCost / staminaGoldCost;
                        stamina += actualConvertValue;
                        guildTokens -= actualConvertValue * guildTokensGoldCost;
                    } else
                    {
                        continue;
                    }

                    guildTokens -= preferedConvertValue;
                    break;
                    
                default:
                    continue;
            }

        } while (convertFrom != ExitCode);
    }
}
