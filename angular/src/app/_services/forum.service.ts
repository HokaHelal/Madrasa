import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Forum } from '../_models/Forum';
import { NewLike } from '../_models/newLike';
import { NewPost } from '../_models/NewPost';
import { NewTopic } from '../_models/NewTopic';
import { Post } from '../_models/Post';
import { Section } from '../_models/Section';
import { SectionMain } from '../_models/SectionMain';
import { Topic } from '../_models/Topic';
import { TopicMain } from '../_models/TopicMain';

@Injectable({
  providedIn: 'root',
})
export class ForumService {
  constructor(private httpClient: HttpClient) {}

  getMainForum(classId: number) {
    return this.httpClient.get<Forum[]>(
      environment.baseUrl + 'forum/topic/class/' + classId,
      {}
    );
  }

  getTopicsBySectionId(sectionId: number, classId: number) {
    return this.httpClient.get<Section>(
      environment.baseUrl + 'forum/section/' + sectionId + '/class/' + classId,
      {}
    );
  }
  getLatestTopics(classId: number) {
    return this.httpClient.get<TopicMain[]>(
      environment.baseUrl + 'forum/topic/' + classId + '/get-latest/',
      {}
    );
  }

  TogglePin(topicId: number) {
    return this.httpClient.get<boolean>(
      environment.baseUrl + 'forum/topic/' + topicId + '/toggle-pin/',
      {}
    );
  }

  getTopicById(topicId: number) {
    return this.httpClient.get<Topic>(
      environment.baseUrl + 'forum/topic/' + topicId,
      {}
    );
  }

  getPostsByAuthorId(authorId: number) {
    return this.httpClient.get<Post>(
      environment.baseUrl + 'forum/post/profile/' + authorId,
      {}
    );
  }

  getDropDownSections(classId: number) {
    return this.httpClient.get<SectionMain[]>(
      environment.baseUrl + 'forum/sections/' + classId,
      {}
    );
  }

  getTopicsByAuthorId(authorId: number) {
    return this.httpClient.get<Post>(
      environment.baseUrl + 'forum/topic/profile/' + authorId,
      {}
    );
  }

  addTopic(topic: NewTopic) {
    return this.httpClient.post(
      environment.baseUrl + 'forum/new-topic/',
      topic
    );
  }

  addPost(post: NewPost) {
    return this.httpClient.post(environment.baseUrl + 'forum/new-post/', post);
  }

  ToggleLike(newLike: NewLike) {
    let likeParams = new HttpParams();
  
    likeParams = likeParams.append("threadId", newLike.threadId.toString());
    likeParams = likeParams.append("userId", newLike.userId.toString());
    likeParams = likeParams.append("isTopic", newLike.isTopic.toString());
  

    return this.httpClient.get<boolean>(
      environment.baseUrl + 'forum/topic/toggle-like/',
      {params: likeParams}
    );
  }
}
