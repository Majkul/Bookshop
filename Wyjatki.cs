//Koszyk
using Microsoft.VisualBasic;

class KoszykException : Exception{
    public KoszykException(string message) : base(message){}
}
class KoszykIsEmptyException : KoszykException{
    public KoszykIsEmptyException(string message) : base(message){}
}
class ItemNotInKoszykException : KoszykException{
    public ItemNotInKoszykException(string message) : base(message){}
}
//Zamówienia
class ZamowienieException : Exception{
    public ZamowienieException(string message) : base(message){}
}
class ZamowienieIsOplaconeException : ZamowienieException{
    public ZamowienieIsOplaconeException(string message) : base(message){}
}
class ZamowienieDoesNotExistException : ZamowienieException{
    public ZamowienieDoesNotExistException(string message) : base(message){}
}
class WrongAddressException : ZamowienieException{
    public WrongAddressException(string message) : base(message){}
}
class WrongStatusException : ZamowienieException{
    public WrongStatusException(string message) : base(message){}
}
//Płatności
class PlatnoscException : Exception{
    public PlatnoscException(string message) : base(message){}
}
class PlatnoscFailedException : PlatnoscException{
    public PlatnoscFailedException(string message) : base(message){}
}
//Produkty
class ProduktException : Exception{
    public ProduktException(string message) : base(message){}
}
class ProduktDoesNotExistException : ProduktException{
    public ProduktDoesNotExistException(string message) : base(message){}
}
class ProduktIsNotAvailableException : ProduktException{
    public ProduktIsNotAvailableException(string message) : base(message){}
}
class ProduktAlreadyExistsException : ProduktException{
    public ProduktAlreadyExistsException(string message) : base(message){}
}
class ProduktIsNotPhysicalException : ProduktException{
    public ProduktIsNotPhysicalException(string message) : base(message){}
}
//Pracownik
class PracownikException : Exception{
    public PracownikException(string message) : base(message){}
}
class BrakZamowienDoWyslaniaException : PracownikException{
    public BrakZamowienDoWyslaniaException(string message) : base(message){}
}
class WrongProductNameException : PracownikException{
    public WrongProductNameException(string message) : base(message){}
}
class WrongPriceException : PracownikException{
    public WrongPriceException(string message) : base(message){}
}
class WrongTypeException : PracownikException{
    public WrongTypeException(string message) : base(message){}
}


