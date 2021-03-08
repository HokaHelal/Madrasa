import { AfterViewInit, Component, ElementRef, EventEmitter, OnDestroy, OnInit, Output, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';
import { take } from 'rxjs/operators';
import { ChatMessage } from 'src/app/_models/ChatMessage';
import { PeerData } from 'src/app/_models/peerData';
import { SignalInfo } from 'src/app/_models/SignalInfo';
import { User } from 'src/app/_models/user';
import { UserInfo } from 'src/app/_models/UserInfo';
import { AuthService } from 'src/app/_services/auth.service';
import { RtcService } from 'src/app/_services/Rtc.service';
import { SignalrService } from 'src/app/_services/signalr.service';
import { VideoStreamComponent } from '../video-stream/video-stream.component';

@Component({
  selector: 'app-class-room',
  templateUrl: './class-room.component.html',
  styleUrls: ['./class-room.component.scss']
})
export class ClassRoomComponent implements OnInit, OnDestroy, AfterViewInit {

  activeVideo: true;
 // @ViewChild('myCam') videoPlayer: ElementRef;
  @ViewChildren(VideoStreamComponent) videoPlayers: QueryList<VideoStreamComponent>;

  public users$: Observable<Array<UserInfo>>;

  public subscriptions = new Subscription();
  private stream;

  public dataString: string;
  public userVideo: string;
  private currentUserInfo: UserInfo;

  user: User;

  constructor(private rtcService: RtcService,
    private userService: AuthService,
    private toastr: ToastrService,
    private signalR: SignalrService) { 
    
      this.users$ = this.signalR.onlineUsers$;
      this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
  }
  ngAfterViewInit() {
    // viewChildren is set
    console.log(this.videoPlayers.toArray());
  }

  async ngOnInit() {
    let currentUserInfo = new UserInfo(this.user.name, this.user.username);
    await this.signalR.startConnection(currentUserInfo, this.user.token);
   
    this.subscriptions.add(this.signalR.newPeer$.subscribe((user: UserInfo) => {
      this.toastr.success(`${user.username} is joinned the room`)
    }));

    this.subscriptions.add(this.signalR.myConnectionId$.subscribe((connectionId: string) => {
      currentUserInfo.connectionId = connectionId;
      console.log('currentUserInfo.connectionId : ' + currentUserInfo.connectionId);
    }));

    this.subscriptions.add(this.signalR.disconnectedPeer$.subscribe((user: string) => {
      this.toastr.info(`${user} is leftout`)
    }));

   // this.InitMyStream();
    console.log(this.videoPlayers.toArray());
  }

  ngOnDestroy() {
    this.signalR.stopHubConnection();
    this.subscriptions.unsubscribe();
  }

  async InitMyStream() {
    this.stream = await navigator.mediaDevices.getUserMedia({ video: true, audio: true });
    const peer = this.rtcService.createPeer(this.stream, this.currentUserInfo.connectionId, true);
    this.rtcService.currentPeer = peer;     
    let peerData : PeerData = { connectionId: this.currentUserInfo.connectionId, stream: this.stream};
    this.signalR.sendStream(peerData);
 }

}
