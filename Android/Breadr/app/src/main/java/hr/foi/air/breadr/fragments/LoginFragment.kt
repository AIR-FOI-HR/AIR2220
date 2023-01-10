package hr.foi.air.breadr.fragments

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.annotation.StringRes
import androidx.fragment.app.Fragment
import hr.foi.air.breadr.LoginActivity
import hr.foi.air.breadr.MainActivity
import hr.foi.air.breadr.R.layout.fragment_login
import hr.foi.air.breadr.data.DataRepository
import hr.foi.air.breadr.databinding.ActivityLoginBinding
import hr.foi.air.breadr.databinding.FragmentLoginBinding
import hr.foi.air.core.LoadDataAuthenticationListener
import hr.foi.air.core.LoadDataItemListener

class LoginFragment : Fragment(), LoadDataAuthenticationListener {
    private lateinit var binding: FragmentLoginBinding
    private var authResponse: Boolean = false
    private var dataAuthListener: LoadDataAuthenticationListener = this

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        binding = FragmentLoginBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        // linking buttons:
        binding.btnLogin.setOnClickListener { authenticatorLogin() }
    }

    private fun authenticatorLogin(){
        //load data
        //check data before sending
        val usr = binding.usernameInput.text
        val pass = binding.passwordInput.text

        if(usr.isNullOrBlank() || pass.isNullOrBlank()){
            Toast.makeText(this.requireContext(), "Username or password are empty!", Toast.LENGTH_SHORT).show()
        }else{
            //calling repo
            //DataRepository().loadLogin(this.requireContext(), dataAuthListener, usr.toString(), pass.toString())

            //temp
            val mainAct = Intent(activity, MainActivity::class.java)
            startActivity(mainAct)
        }
    }

    //response handled
    override fun onAuthenticationLoaded(status: Boolean) {
        authResponse = status
        if(authResponse){
            //Toast.makeText(this.requireContext(), "Success!", Toast.LENGTH_SHORT).show()
            //login user - store data
            val mainAct = Intent(activity, MainActivity::class.java)
            startActivity(mainAct)
        }else{
            Toast.makeText(this.requireContext(), "Username or password is incorrect!", Toast.LENGTH_SHORT).show()
        }
    }
}