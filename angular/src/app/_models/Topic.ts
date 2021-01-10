import { Like } from "./Like";
import { Post } from "./Post";

export interface Topic {
    id: number;
    sectionName: string;
    isPinned: boolean;
    title: string;
    content: string;
    authorId: number;
    authorName: string;
    authorPhoto: string;
    created: string;
    posts: Post[];
    likes: Like[];
  }
