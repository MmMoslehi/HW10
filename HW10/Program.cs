using HW10.Contracts;
using HW10.Entities;
using HW10.Enums;
using HW10.Repositories;
using HW10.Services;

IUserRepository userRepository = new UserRepositoryDb();
IAuthenticationSevice authenticationSevice = new AuthenticationService(userRepository);
IUserService userService = new UserService(userRepository);
Result isValid;
bool logUser = false;
StatusEnum status;

mainmenu();

void mainmenu()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Enter Command : ");
    string result = Console.ReadLine()!;
    Console.ForegroundColor = ConsoleColor.Green;
    var split = result.Split(" ");
    string want = split[0].ToLower();
    switch (want)
    {
        case "login":
            isValid = authenticationSevice.Login(split[2], split[4]);
            if (!isValid.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{isValid.Message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{isValid.Message}");
                logUser = true;
            }
            break;
        case "register":
            isValid = authenticationSevice.Register(new User(split[2], split[4]));
            if (!isValid.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{isValid.Message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{isValid.Message}");
            }
            break;
        case "change":
            if (logUser == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not logged in yet");
                mainmenu();
            }
            if (split[2] == "available")
                status = StatusEnum.available;
            else if (split[2] == "notAvailable")
                status = StatusEnum.notAvaliable;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("try again");
                mainmenu();
            }
            string userNameCurrentUser = authenticationSevice.GetCurrentUser()!;
            isValid = userRepository.ChangeStatus(userNameCurrentUser!, status);
            if (isValid.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{isValid.Message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"try again");
            }
            break;
        case "search":
            if (logUser == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not logged in yet");
                mainmenu();
            }
            var rslt = userService.Search(split[2]);
            if (rslt is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("try again");
                mainmenu();
            }
            foreach (var item in rslt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("successful");
                Console.WriteLine($"{item.userName} | {item.status}");
            }
            break;
        case "changepassword":
            if (logUser == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not logged in yet");
                mainmenu();
            }
            isValid = userService.ChangePassword(authenticationSevice.GetCurrentUser()!, split[2], split[4]);
            if (!isValid.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{isValid.Message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{isValid.Message}");
            }
            break;
        case "logout":
            logUser = false;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("try again");
            mainmenu();
            break;
    }
    mainmenu();
}
File.WriteAllText("Database/CurrentUser.json", "[]");


