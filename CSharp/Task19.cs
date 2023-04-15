public class TaskNineteen
{
    public static void Main(String[] args)
    {
        int evadeCooldown = 5;
        int chaosboltDamage = 100;
        int chaosboltCooldown = 3;
        int curseManacost = 3;

        int playerHealth = 1000;
        int playerMana = 0;
        int bossHealth = 1000;

        int bossAttackDamage = 50;
        int playerAttackDamage = 10;

        int evadeLastUsage = -evadeCooldown;
        int chaosboltLastUsage = -chaosboltCooldown;

        int currentTurn = 0;

        while (playerHealth > 0 && bossHealth > 0)
        {
            currentTurn++;
            Console.WriteLine($"Turn {currentTurn}:{Environment.NewLine}Player health: {playerHealth} - Boss health: {bossHealth}");

            if (currentTurn - evadeLastUsage >= evadeCooldown)
            {
                evadeLastUsage = currentTurn;
                Console.WriteLine("Player used evade!");
                continue;
            }

            playerHealth -= bossAttackDamage;

            if (currentTurn - chaosboltLastUsage >= chaosboltCooldown)
            {
                bossHealth -= chaosboltDamage;
                chaosboltLastUsage = currentTurn;
                Console.WriteLine("Player used chaosbolt!");
                continue;
            }

            if (playerMana >= curseManacost)
            {
                playerAttackDamage += 15;
                playerMana -= curseManacost;
                Console.WriteLine("Player cursed boss!");
                continue;
            }

            playerMana += 1;
            bossHealth -= playerAttackDamage;
        }

        if (bossHealth <= 0)
        {
            Console.WriteLine("Boss defeated!");
        } else
        {
            Console.WriteLine("Wipe, healer noob, 0 heaing");
        }
    }
}
