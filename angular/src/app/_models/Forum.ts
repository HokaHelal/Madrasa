import { TopicMain } from "./TopicMain";

export interface Forum {
    id: number;
    name: string;
    orderNum: number;
    topics: TopicMain[];
}
