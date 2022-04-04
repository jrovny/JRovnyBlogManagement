export interface PostEdit {
    postId: number;
    title: string;
    content: string;
    image: string;
    slug: string;
    published: boolean;
    publishedDate: Date;
    createdDate: Date;
}
