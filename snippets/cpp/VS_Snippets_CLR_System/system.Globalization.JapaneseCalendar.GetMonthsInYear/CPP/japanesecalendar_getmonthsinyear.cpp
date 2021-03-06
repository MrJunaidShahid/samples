
using namespace System;
using namespace System::Globalization;

int main()
{
   // Creates and initializes a JapaneseCalendar.
   JapaneseCalendar^ myCal = gcnew JapaneseCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 1; y <= 5; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Displays the value of the CurrentEra property.
   Console::Write( "CurrentEra:" );
   for ( int y = 1; y <= 5; y++ )
      Console::Write( "\t {0}", myCal->GetMonthsInYear( y, JapaneseCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 1; y <= 5; y++ )
         Console::Write( "\t {0}", myCal->GetMonthsInYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();
   }
}
