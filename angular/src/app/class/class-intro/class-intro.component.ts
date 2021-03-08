import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { User } from 'src/app/_models/user';
import { UserInfo } from 'src/app/_models/UserInfo';
import { AuthService } from 'src/app/_services/auth.service';
import { SignalrService } from 'src/app/_services/signalr.service';


@Component({
  selector: 'app-class-intro',
  templateUrl: './class-intro.component.html',
  styleUrls: ['./class-intro.component.scss']
})
export class ClassIntroComponent implements OnInit {
  ngOnInit(): void {
    this.cam.checked = false;
    this.mic.checked = false;
  }
  @ViewChild('myCam') videoPlayer: ElementRef;

  cam: any = {};
  mic: any = {};

  user: User;
  userMedia: any;

  constructor(private accountService: AuthService, 
    private signalrServic: SignalrService,
    private router: Router) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
  }

  async onCamSelected() {
    this.cam.checked = !this.cam.checked;   
    
    if(this.cam.checked) {
      this.InitMyStream();
    }
    if(this.userMedia) {
      this.userMedia.getVideoTracks()[0].enabled = this.mic.checked;
    }
 
    if (!this.cam.checked && !this.mic.checked) {
      this.ClearMyStream();
    }
  }

  async onMicSelected() {
    this.mic.checked = !this.mic.checked;     
    this.InitMyStream();

    this.userMedia.getAudioTracks()[0].enabled = this.mic.checked;
   
    if (!this.cam.checked && !this.mic.checked) {
      this.ClearMyStream();
    }
  }

  ClearMyStream() {

    if(this.videoPlayer) {
      this.videoPlayer.nativeElement.srcObject = null;
      this.videoPlayer.nativeElement.pause();
    }
    this.userMedia?.getTracks().forEach(function(track) { track.stop(); }); 
    this.userMedia = null;
  }

  async InitMyStream() {
    if(this.cam.checked && !this.userMedia) {      
      this.userMedia = await navigator.mediaDevices.getUserMedia({ video: true,
           audio: true });
      this.videoPlayer.nativeElement.srcObject = this.userMedia;
      this.videoPlayer.nativeElement.load();
      this.videoPlayer.nativeElement.play();    
  }
 }

 async JoinClassroom() {
  this.router.navigate(["/app/classroom/"]);
 }
}