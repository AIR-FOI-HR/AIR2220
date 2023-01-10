package hr.foi.air.breadr

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.fragment.app.Fragment
import hr.foi.air.breadr.databinding.ActivityLoginBinding
import hr.foi.air.breadr.fragments.LoginFragment
import hr.foi.air.breadr.fragments.ChooseFragment
import hr.foi.air.breadr.fragments.SignupFragment

class LoginActivity : AppCompatActivity() {
    private var currentFragment : Fragment? = null
    private lateinit var binding : ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        //binding = ActivityLoginBinding.inflate(layoutInflater)
        //val view = binding.root
        //setContentView(view)

        binding = ActivityLoginBinding.inflate(layoutInflater)

        var loginFragment : Fragment = ChooseFragment(this, binding)

        this.supportFragmentManager.beginTransaction()
            .replace(binding.fcvLogin.id, loginFragment)
            .commit()

        //username = findViewById<EditText>(R.id.usernameInput)
        //password = findViewById<EditText>(R.id.passwordInput)
        //btn_logIn = findViewById<Button>(R.id.btnLogin)

        //btn_logIn.setOnClickListener{
        //    val usr = username.text
        //    val pass = password.text
            //continue with login logic, send data to API, if all good save user as logged in
        //}
    }

    override fun onBackPressed() {
        val currFragment: Fragment? = supportFragmentManager.findFragmentById(R.id.fcv_login)
        if(currFragment is hr.foi.air.breadr.fragments.ChooseFragment){
            super.onBackPressed()
            finish()
        }else{
            var loginFragment : Fragment = ChooseFragment(this, binding)
            this.supportFragmentManager.beginTransaction()
                .replace(binding.fcvLogin.id, loginFragment)
                .commit()
        }
    }

    //companion object{
    //    var targetFragment: Fragment = Fragment()
    //}
}