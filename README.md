# PasswordsHash
![.NetV](https://img.shields.io/static/v1?style=badge&message=5.0&color=blueviolet&label=.Net) ![WPF](https://img.shields.io/static/v1?message=WPF&color=navy&label=) ![Forks](https://img.shields.io/github/forks/AntonKharchuk/PasswordsHash?style=social)

**PasswordsHash** - is an application for windows that will allow you to keep your passwords secret

## Encryption

All your passwords are saved in encrypted format:

![dfasd](PasswordsHash/img/dataSave.png)


This method makes all encryption:

```C#
foreach (var item in charArr)
{
    if (!char.IsDigit(item))
    {
        int Unicode = (int) item;
        Unicode--;
        rescchars.Add((char)Unicode);
    }
    else
    {
        rescchars.Add(item);
    }
}
```
You can adjust it for yourself, just don't forget to decode your data in `MainWindow.xaml.cs` file.

## Usage

![firstAdd](PasswordsHash/img/firstAdd.png)

![secondAdd](PasswordsHash/img/secondAdd.png)

![exumple](PasswordsHash/img/exumple.png)


## Example

![useExumple](PasswordsHash/img/useExumple.png)
