export interface TopicMain {
    id: number;
    isPinned: boolean;
    title: string;
    authorId: number;
    authorName: string;
    authorPhoto: string;
    created: string;
    content: string;
    lastActive: Date;
    lastPostId: number;
    lastPostBy: string;
    postsCount: number;

}
