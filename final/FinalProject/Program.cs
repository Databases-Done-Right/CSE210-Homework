using System;
using static Admin;
using static Division;
using static Entry;
using static GraphicArt;
using static Judge;
using static Other;
using static Patron;
using static Photo;
using static SuperAdmin;
using static User;

class Program
{
    static void Main(string[] args)
    {
        User initialUser = new User();
        while(!initialUser.isLoggedIn()) {
            User user = initialUser.Login();
            if(user != null) { initialUser = user; }
        }
        Division division = new Division();
        List<Division> divisions = division.LoadDivisions();
        int userInput = 0;
        while(userInput != 999999) {
            initialUser.DisplayMainMenu(divisions);
        }
    }
}