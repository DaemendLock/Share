#region Constants
const string CommandIceShot = "1";
const string CommandDitonator = "2"; // Пока сделаю чтобы взрыв восстанавливал ману 
const string CommandReflectiveScreen = "3";
const string CommandIceBlock = "4";
const int CommandFirework = 1;
const int CommandFlash = 2;
const int CommandStealingHealth = 3;
const int CommandRampage = 4;
#endregion

Random random = new Random();

#region WizzardStats
float healthWizard = 300;
float maxValuerHealthWizard = 300;

int manahWizard = 600;
float iceShot = 50;
int iceShotCost = 30;
float ditonator = 500;
int ditonatorCost = 90;
float reducedProtection = 70; // в процентах
float reflectiveScreen = 60; // в процентах
int reflectiveScreenCost = 40;
int recoveryMana = 150;
float recoveryWizard = 150;
int iceBlockCost = 50;
int countIceShot = 0;
int maxValueCount = 4;
float percentMuliplier = 0.01f;
bool isUsedReflectiveScreen = false;

string someString = "Ход ледяного мага";
#endregion

#region LordStats
float healthLordFaceless = 1500;
float maxValueHealth = 1500;
int minValueHealth = 500;

int countRampage = 0;
float armorLordFaceless = 40; // это процент урона который пройдёт по боссу
// Написать 4 заклинания для босса
float firework = 70;
// Вспышка заставляет промахнутся
// Вампир придумать условия, либо снизить
float vampire = 50;
float recoveryLordFaceless = 300;
float stealingHealth = 15; // в процентах, подумать над этим, скорей всего в процентах оставлю и будет применяться если здоровье меньше половины 
float rampage = 200;
bool isWoking = true;
int minValueEnemyAttack = 1;
int maxValueEnemyAttack = 5;
float currentDamageLordFaceless = 0;

int currentAttack;
#endregion

while (healthWizard > 0 && healthLordFaceless > 0) {

    #region CurrentStateWriter
    //Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    //Console.SetCursorPosition(0, 15);
    Console.WriteLine($"Состояние мага:\n здоровье - {healthWizard},\n мана - {manahWizard},\n кристаллов для использования способности детонатор {countIceShot}\n");
    //Console.SetCursorPosition(0, 19);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{new string('-', someString.Length)}");
    Console.WriteLine(someString);
    Console.WriteLine($"{new string('-', someString.Length)}");
    Console.WriteLine($"{CommandIceShot} - Ледяной выстрел (Отнимает 50 единиц здоровья у врага за 1 выстрел и оставляет на враге кристалл)\n");
    Console.WriteLine($"{CommandDitonator} - Детонатор (Если у врага скопилось 3 и более кристалл, то их можно взорвать нанеся 300 единиц урона и снизить защиту на 1 ход)\n");
    Console.WriteLine($"{CommandReflectiveScreen} - Отражающий экран (отражает 70% урона и возвращает обратно во врага 70%)\n");
    Console.WriteLine($"{CommandIceBlock} - Ледяная глыба (восстанавливает 50% здоровья и даёт неуязвимость на 1 ход)\n");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Состояние босса Безликого: здоровье - {healthLordFaceless}");
    Console.WriteLine(countRampage);
    Console.ForegroundColor = ConsoleColor.White;
    #endregion
    
    string userInput = Console.ReadLine();
    float armorWizard = 70; // это процент урона который пройдёт по игроку

    switch (userInput) {
        case CommandIceShot:

            if (manahWizard > 0) {
                healthLordFaceless -= iceShot * armorLordFaceless * percentMuliplier;
                manahWizard -= iceShotCost;
                countIceShot++;
            } else {
                Console.WriteLine("Недостаточно маны");
            }

            break;

        case CommandDitonator:

            if (manahWizard > 0) {
                if (countIceShot >= maxValueCount) {
                    healthLordFaceless -= ditonator * armorLordFaceless * percentMuliplier;
                    manahWizard -= ditonatorCost;
                    countIceShot = 0;
                } else if (countIceShot < maxValueCount) {
                    countIceShot = 0;
                    Console.WriteLine("Не достаточно кристаллов для того чтобы активировать данное заклинание");
                }
            } else {
                manahWizard += recoveryMana;
                Console.WriteLine("Недостаточно маны");
            }
            break;

        case CommandReflectiveScreen:

            if (manahWizard > 0) {
                // это способность работает следующим образом, маг накладывает на себя щит и ждёт когда враг нанесёт урон
                isUsedReflectiveScreen = true;
                armorWizard = 30;
                manahWizard -= reflectiveScreenCost;
                Console.WriteLine($"Чародей поднял зеркальный щит");
            } else {
                manahWizard += recoveryMana;
                Console.WriteLine("Недостаточно маны");
            }

            break;

        case CommandIceBlock:

            if (manahWizard > 0) {
                armorWizard = 0;
                healthWizard += recoveryWizard;

                if (healthWizard >= maxValuerHealthWizard) {
                    healthWizard = maxValuerHealthWizard;
                }
                manahWizard -= iceBlockCost;
            } else {
                manahWizard += recoveryMana;
                Console.WriteLine("Недостаточно маны");
            }

            break;

        default:
            manahWizard += recoveryMana;
            Console.WriteLine("Нет такого действия");
            break;
    }

    if (manahWizard < 0) {
        manahWizard = 0;
    }

    currentAttack = random.Next(4, 5);

    switch (currentAttack) {
        case CommandFirework:
            currentDamageLordFaceless = firework * armorWizard * percentMuliplier;
            break;

            //case CommandFlash: // способность заставляющая промахнуться, то есть по врагу прилетает 0 урона 

            //Реализовать

            break;

        case CommandStealingHealth:

            if (healthLordFaceless < minValueHealth) {
                currentDamageLordFaceless = vampire * armorWizard * percentMuliplier;
                healthLordFaceless += recoveryLordFaceless;
            } else if (healthLordFaceless > maxValueHealth) {
                healthLordFaceless = maxValueHealth;
            }

            break;

        case CommandRampage:

            if (healthLordFaceless < minValueHealth)
            {
            countRampage++;

                if (countRampage >= 3) {
                    currentDamageLordFaceless = rampage * armorWizard * percentMuliplier ;
                } else {
                    currentDamageLordFaceless = 0;
                }
            } else {
                currentDamageLordFaceless = 0;
            }

        break;
    }

    healthWizard -= currentDamageLordFaceless;

    Console.WriteLine($"Волшебнику нанесли {currentDamageLordFaceless}");

    if (isUsedReflectiveScreen == true) {
        healthLordFaceless -= currentDamageLordFaceless * 0.7f;
        isUsedReflectiveScreen = false;
        Console.WriteLine($"Вернулось {currentDamageLordFaceless * 0.7f} урона");
    }

}




#region VictoryCheck
if (healthWizard <= 0 && healthLordFaceless <= 0) {
    Console.WriteLine("Ни кто не уцелел в этой битве");
} else if (healthWizard <= 0) {
    Console.WriteLine("Безликий одержал победу");
} else if (healthLordFaceless <= 0) {
    Console.WriteLine("Финальная битва закончена, чародей победил");
}
#endregion

