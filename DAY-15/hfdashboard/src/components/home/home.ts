import { Component } from '@angular/core';
import { Description } from '../description/description';
import { WelcomeBanner } from '../welcome-banner/welcome-banner';
import { InsuranceProfiles } from '../insurance-profiles/insurance-profiles';

@Component({
  selector: 'app-home',
  imports: [Description,WelcomeBanner,InsuranceProfiles],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

}
