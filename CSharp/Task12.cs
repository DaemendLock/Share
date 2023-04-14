public class TaskTwelve
{
    public static void Main(String[] args)
    {
        const int GoldStartValue = 0;
        const int StaminaStartValue = 0;
        const int GuildTokensStartVakue = 100;

        const string ExitCode = "0";
        const string GoldId = "1";
        const string StaminaId = "2";
        const string GuildTokensId = "3";

        int gold = GoldStartValue;
        int stamina = StaminaStartValue;
        int guildTokens = GuildTokensStartVakue;

        string convertFrom;
        string convertTo;
        int convertValue;

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
            convertValue = Convert.ToInt32(Console.ReadLine());

            switch (convertFrom)
            {
                case GoldId:

                    if (convertTo.Equals(StaminaId))
                    {
                        stamina += convertValue;
                    } else if (convertTo.Equals(GuildTokensId))
                    {
                        guildTokens += convertValue;
                    } else
                    {
                        continue;
                    }

                    gold -= convertValue;
                    break;
                case StaminaId:

                    if (convertTo.Equals(GuildTokensId))
                    {
                        guildTokens += convertValue;
                    } else if (convertTo.Equals(GoldId))
                    {
                        gold += convertValue;
                    } else
                    {
                        continue;
                    }

                    stamina -= convertValue;
                    break;
                case GuildTokensId:

                    if (convertTo.Equals(StaminaId))
                    {
                        stamina += convertValue;
                    } else if (convertTo.Equals(GoldId))
                    {
                        gold += convertValue;
                    } else
                    {
                        continue;
                    }

                    guildTokens -= convertValue;
                    break;
                default:
                    continue;
            }

        } while (convertFrom != ExitCode);
    }
}
