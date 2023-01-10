package hr.foi.air.breadr.fragments

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import hr.foi.air.breadr.LoginActivity
import hr.foi.air.breadr.databinding.ActivityLoginBinding
import hr.foi.air.breadr.databinding.FragmentChooseBinding

class ChooseFragment(activity: AppCompatActivity, actBinding: ActivityLoginBinding): Fragment() {
    private lateinit var binding: FragmentChooseBinding
    private var act: AppCompatActivity
    private var actBinding: ActivityLoginBinding

    init {
        this.act = activity
        this.actBinding = actBinding
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        binding = FragmentChooseBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        // linking buttons:
        binding.btnLogin.setOnClickListener{ changeLoginPage() }
        binding.btnSignup.setOnClickListener{ changeSignupPage() }
    }

    private fun changeLoginPage(){
        val loginFragment: Fragment = LoginFragment()

        act.supportFragmentManager.beginTransaction()
            .replace(actBinding.fcvLogin.id, loginFragment)
            .commit()
    }

    private fun changeSignupPage(){
        val signupFragment: Fragment = SignupFragment()

        act.supportFragmentManager.beginTransaction()
            .replace(actBinding.fcvLogin.id, signupFragment)
            .commit()
    }

}