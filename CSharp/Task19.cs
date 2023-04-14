public class TaskNineteen
{
    public static void Main(String[] args)
    {
        int EvadeCooldown = 5;
        int ChaosboltDamage = 100;
        int ChaosboltCooldown = 3;
        int CurseManacost = 3;

        int playerHealth = 1000;
        int playerMana = 0;
        int bossHealth = 1000;

        int bossAttack = 50;
        int playerAttack = 10;

        int evadeLastUsage = -EvadeCooldown;
        int chaosboltLastUsage = -ChaosboltCooldown;
        int curseLastUsage = -CurseCooldown;

        int currentTurn = 0;

        while (playerHealth > 0 && bossHealth > 0)
        {
            currentTurn++;
            Console.WriteLine($"Turn {currentTurn}:{Environment.NewLine}Player health: {playerHealth} - Boss health: {bossHealth}");

            if (currentTurn - evadeLastUsage >= EvadeCooldown)
            {
                evadeLastUsage = currentTurn;
                Console.WriteLine("Player used evade!");
                continue;
            }

            playerHealth -= bossAttack;

            if (currentTurn - chaosboltLastUsage >= ChaosboltCooldown)
            {
                bossHealth -= ChaosboltDamage;
                chaosboltLastUsage = currentTurn;
                Console.WriteLine("Player used chaosbolt!");
                continue;
            }

            if (playerMana >= CurseManacost)
            {
                playerAttack += 15;
                playerMana -= CurseManacost;
                Console.WriteLine("Player cursed boss!");
                continue;
            }
            
            playerMana += 1;
            bossHealth -= playerAttack;
        }

        if(bossHealth <= 0)
        {
            Console.WriteLine("Boss defeated!");
        } else 
        {
            Console.WriteLine("Wipe, healer noob, 0 heaing");
        }
    }
}
