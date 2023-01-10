package hr.foi.air.breadr.fragments

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import hr.foi.air.breadr.data.DataRepository
import hr.foi.air.breadr.databinding.FragmentSignupBinding
import hr.foi.air.core.LoadDataAuthenticationListener

class SignupFragment:Fragment(),LoadDataAuthenticationListener {
    private lateinit var binding: FragmentSignupBinding
    private var authResponse: Boolean = false
    private var dataAuthListener: LoadDataAuthenticationListener = this

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        binding = FragmentSignupBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        // linking buttons:
        binding.btnSignup.setOnClickListener { authenticatorSignup() }
    }

    private fun authenticatorSignup() {
        val name = binding.nameInput.text
        val surname = binding.surnameInput.text
        val username = binding.usernameInput.text
        val email = binding.emailInput.text
        val password = binding.passwordInput.text

        if(name.isNullOrBlank() || surname.isNullOrBlank() || username.isNullOrBlank() || email.isNullOrBlank() || password.isNullOrBlank()){
            Toast.makeText(this.requireContext(), "Some fields are empty!", Toast.LENGTH_SHORT).show()
        }else{
            //DataRepository().loadSignup(this.requireContext(), dataAuthListener, name.toString(), surname.toString(), username.toString(), email.toString(), password.toString())
        }
    }

    override fun onAuthenticationLoaded(status: Boolean) {
        authResponse = status
        if(authResponse){
            Toast.makeText(this.requireContext(), "Successfully registered!", Toast.LENGTH_SHORT).show()
        }else{
            Toast.makeText(this.requireContext(), "Something went wrong!", Toast.LENGTH_SHORT).show()
        }
    }
}