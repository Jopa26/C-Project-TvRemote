using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRemote.Utils;

namespace TVRemote
{
    internal class Remote
    {
        public string decodeInputs(string command)
        {
            if (string.IsNullOrEmpty(command)) return "";
            else
            {
                if (command.ToLower().StartsWith("p"))
                {
                    IntermediaryValues.power = !IntermediaryValues.power;
                    if (IntermediaryValues.power)
                    {
                        return "TV turned on";
                    }
                    else
                    {
                        return "TV turned off";
                    }

                }
                if (IntermediaryValues.power)
                {
                    if (command.ToLower().StartsWith("v"))
                    {
                        string s = command.Substring(command.Length - 1);
                        if (s == "+")
                        {
                            IntermediaryValues.volume++;

                            return "Volume Increased: " + IntermediaryValues.volume;
                        }
                        else if (s == "-")
                        {
                            IntermediaryValues.volume--;
                            if (IntermediaryValues.volume < 0)
                                IntermediaryValues.volume = 0;

                            return "Volume decreased: " + IntermediaryValues.volume;
                        }

                        //Console.WriteLine("We received: "+s);

                    }
                    else if (command.ToLower().StartsWith("c"))
                    {
                        if (command.ToLower().Contains("h")) {
                            string s = command.Substring(command.Length - 1);
                            if (s == "+")
                            {
                                IntermediaryValues.channel++;

                                return "Channel increased: " + IntermediaryValues.channel;

                            }
                            else if (s == "-")
                            {
                                IntermediaryValues.channel--;
                                if (IntermediaryValues.channel < 0)
                                    IntermediaryValues.channel = 0;
                                return "Channel decreased: " + IntermediaryValues.channel;
                            }

                            //Console.WriteLine("We received: "+s);
                        }
                    }
                    else if (command.ToLower().StartsWith("i"))
                    {
                        //if contains increase
                        if (command.ToLower().Contains("increase"))
                        {
                            if (command.ToLower().Contains("volume"))
                            { 
                                    IntermediaryValues.volume++;

                                    return "Volume increased: " + IntermediaryValues.volume;

                            } 
                            
                            else if (command.ToLower().Contains("channel"))
                            {
                                IntermediaryValues.channel++;

                                return "Channel increased: " + IntermediaryValues.channel;

                            } 
                        }
                        //if contains decrease
                        else if (command.ToLower().Contains("decrease"))
                        {
                            
                                if (command.ToLower().Contains("volume"))
                                {
                                    IntermediaryValues.volume--;

                                    if(IntermediaryValues.volume < 0)
                                        IntermediaryValues.volume = 0;

                                    return "Volume decreased: " + IntermediaryValues.volume;

                                }

                                else if (command.ToLower().Contains("channel"))
                                {
                                    IntermediaryValues.channel--;
                                
                                    if(IntermediaryValues.channel < 0)
                                        IntermediaryValues.channel = 0;

                                    return "Channel decreased: " + IntermediaryValues.channel;

                                }
                            }
                    }
                    // note: this stub contains two logic: menu and mute : 
                    else if (command.ToLower().StartsWith("m"))
                    {

                        if (command.ToLower().Contains("mute"))
                        {
                            IntermediaryValues.muted = !IntermediaryValues.muted;

                            if (IntermediaryValues.muted)
                                return "Muted";
                            else
                                return "Not muted.";

                        }

                        else if (command.ToLower().Contains("menu"))
                        {

                            return "Smart menu powered by Samsung";

                        }

                    }
                    //following stub also contains logic for menu for smart menu:
                    else if (command.ToLower().StartsWith("s"))
                    {
                        if (command.ToLower().Contains("menu"))
                        {

                            return "Smart menu powered by Samsung";

                        }

                        else if (command.ToLower().Contains("setti"))
                        {

                            return "This is the settings screen by Samsung";

                        }


                    }
                    else
                    {
                        try
                        {
                            int cha = Int32.Parse(command);
                            if (cha > -1)
                            {
                                IntermediaryValues.channel = cha;
                                return "Channel: " + IntermediaryValues.channel;

                            }

                        }
                        catch(Exception e)
                        {
                            
                        }
                    }

                    return "Invalid command.";
                }
                else
                {
                    return "TV is powered off. Turn on first.";
                }
            }
        }
    }
}



/*
dont forget to use these functionsPower On / Off
Increase / Decrease Volume
Increase / Decrease Channel
Mute
Change Channel
Smart Menu
Settings

+ I added:

power


*/


