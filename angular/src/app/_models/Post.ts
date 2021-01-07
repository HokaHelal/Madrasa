import { Like } from "./Like";

export interface Post {
    id: number;
    topicId: number;
    content: string;
    authorId: number;
    authorName: string;
    authorPhoto: string;
    created: Date;
    likes: Like[];
}
