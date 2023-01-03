package hr.foi.air.database.converters
import androidx.room.TypeConverter
import java.util.*

class DateConverter {
    @TypeConverter
    fun fromDate(date: Date) : Long
    {
        return date.time
    }

    @TypeConverter
    fun toDate(timeStamp: Long) : Date
    {
        return Date(timeStamp)
    }
}