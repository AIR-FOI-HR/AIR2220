package hr.foi.air.database.data

import android.content.Context
import hr.foi.air.database.DAO
import hr.foi.air.database.MainDatabase
import hr.foi.air.database.entities.User

object MockData {
    private var dao: DAO? = null

    fun mockData(context: Context){
        dao = MainDatabase.getInstance(context).getDao()

        //check if data already exists

        val user: User = dao!!.getActiveUser()
        if (user != null) {
            val very_active_user: User = User()
            very_active_user.email = "active.person@email.com"
            very_active_user.firstName = "active"
            very_active_user.lastName = "user"
            very_active_user.notifications = true
            very_active_user.loggedIn = true
            very_active_user.password = "V3ry5Tr0ng!"
            dao?.insertUser(very_active_user)
        }
    }
}