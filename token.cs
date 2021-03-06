using System;
using Com.Expload;

[Program]
class MyProgram {
    Mapping<Bytes, int> balances = new Mapping<Bytes, int>();

    public void emit(int tokens) 
    {
	balances.put(Info.Sender(), tokens);
    }

    public int balanceOf(Bytes tokenOwner) 
    {
        return balances.getDefault(tokenOwner, 0);
    }

    public void transfer(Bytes to, int tokens) 
    {
        if (tokens > 0) {
            if (balances.getDefault(Info.Sender(), 0) >= tokens) {
                balances.put(Info.Sender(), balances.getDefault(Info.Sender(), 0) - tokens);
                balances.put(to, balances.getDefault(to, 0) + tokens);
            }
        }
    }
}

class MainClass { public static void Main() {} }
