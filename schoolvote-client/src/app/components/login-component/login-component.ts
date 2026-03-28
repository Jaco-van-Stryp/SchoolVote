import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { AdminLoginCommand, AdminLoginResponse, LoginService } from '../../api';
import { ButtonModule } from 'primeng/button';
@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-login-component',
  imports: [InputTextModule, FormsModule, ButtonModule],
  templateUrl: './login-component.html',
  styleUrl: './login-component.scss',
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  loginService = inject(LoginService);

  onLogin() {
    var adminUser: AdminLoginCommand = {
      username: this.username,
      password: this.password,
    };
    this.loginService.adminLogin(adminUser).subscribe((res: AdminLoginResponse) => {
      console.log(res.jwt);
    });
  }
}
