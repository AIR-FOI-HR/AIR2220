package hr.foi.air.database.data

import android.content.Context
import android.util.Log
import hr.foi.air.core.UserDataSource
import hr.foi.air.core.UserDataSourceListener
import hr.foi.air.core.entities.Receipt
import hr.foi.air.core.entities.User
import hr.foi.air.database.DAO
import hr.foi.air.database.MainDatabase

class DbDataSource(context: Context): UserDataSource  {
    var dao: DAO

    init {
        dao = MainDatabase.getInstance(context).getDao()
    }

    // useless view?
    fun getUserById(userId: Int): User {
        return dao.getUserById(userId)
    }

    // this can be removed or adapted to take listener
    fun getActiveUser(): User {
        return dao.getActiveUser()
    }

    // this can be removed or adapted to take listener
    fun getAllUsers(): User {
        return dao.getActiveUser()
    }

    fun getAllReceipts() : List<Receipt>
    {
        return dao.getAllReceipts()
    }

    fun addReceipt(receipt: Receipt)
    {
        return dao.insertReceipt(receipt as hr.foi.air.database.entities.Receipt)
    }

//    fun loadActiveUser(listener: UserDataSourceListener, context: Context) {
//
//    }

    override fun loadUser(listener: UserDataSourceListener, context: Context) {
        MockData.mockData(context)
        var user = getActiveUser()
        Log.d("Breadr", "user:" + user.toString())
        listener.onUserLoaded(user)
    }
}