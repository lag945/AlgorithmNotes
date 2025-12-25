#include <iostream>
#include <cmath>
#include <string>
#include <iomanip>
#include <map>
#include <sstream>
#include <cctype>
#include <vector> 
#include <algorithm>
#include <unordered_map>
#include <cstring>

using namespace std;

int main()
{   
    int n = 0;
    while(cin>> n)
    {
        long long root[50];
        for(int i = 0; i < n; i++)
        {
            cin >> root[i];
        }

        long long output[51];
        memset(output, 0, sizeof(output));
        // output[3] = 1;
        // output[2] = -1;
        // output[1] = -1;
        // output[0] = 0;
        for(int i = 0; i < n; i++)
        {
            if(i == 0)
            {
                output[1] = 1;
                output[0] = root[i] * -1;
            }
            else
            {
                long long a = 1;
                long long b = root[i] * -1;
                long long temp[51];
                memcpy(temp,output, sizeof(temp));
                memset(output, 0, sizeof(output));
                for(int i = 50; i >= 0; i--)
                {
                    output[i+1] += temp[i] * a;
                    output[i] += temp[i] * b;
                }
            }
        }

        bool first = true;
        for(int i = 50; i >= 0; i--)
        {
            if (i>1)
            {
                if(output[i] == 0)
                    continue;
                if (output[i] > 0)
                {
                    if(first)
                    {
                        first = false;
                        cout << "x^" << i<< " ";  
                    }
                    else
                    {
                        if(output[i] == 1)
                            cout << "+ x^" << i<< " ";
                        else
                            cout << "+ " << output[i]<< "x^" << i<< " ";
                    }
                }            
                else
                {
                    if(output[i] == -1)
                        cout << "- x^" << i<< " "; 
                    else
                        cout << "- " << (output[i] * -1)<< "x^" << i<< " "; 
                }

            }
            else if (i==1)
            {
                if(output[i] == 0)
                    continue;
                if (output[i] > 0)
                {
                    if(first)
                    {
                        first = false;
                        cout << "x ";   
                    }
                    else
                    {
                        if(output[i] == 1)
                            cout << "+ x ";   
                        else     
                            cout << "+ " << output[i]<< "x ";   
                    }  
                }      
                else
                {
                    if(output[i] == -1)
                        cout << "- x ";   
                    else     
                        cout << "- " << (output[i] * -1)<< "x ";
                }
            }    
            else if (i==0)
            {
                if(output[i] == 0)
                {
                    cout << "+ 0 ";
                }
                else
                {
                    if (output[i] > 0)
                        cout << "+ " << output[i]<< " ";           
                    else
                        cout << "- " << (output[i] * -1)<< " ";
                }
            }
        }
        
        cout << "= 0" << endl;

    }
    return 0;
}
