import { Label } from '@gravity-ui/uikit'
import { useRouter } from 'next/navigation'

import { IAuthor } from '~models/author'

interface AuthorCardProps {
	author: IAuthor
}

export function AuthorCard({ author }: AuthorCardProps) {
	const router = useRouter()

	return (
		<Label size={'m'} theme={'clear'} interactive={true}>
			{author.fullName}
		</Label>
	)
}
