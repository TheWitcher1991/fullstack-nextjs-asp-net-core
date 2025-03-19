import { Flex, Text } from '@gravity-ui/uikit'

import { IAuthor } from '~models/author'

import { CardImage, Spacing } from '~packages/ui'
import { staticPath } from '~packages/utils'

interface AuthorCardProps {
	author: IAuthor
}

export function AuthorCard({ author }: AuthorCardProps) {
	return (
		<Flex gap={4}>
			<CardImage
				height={80}
				width={80}
				radius={99}
				src={staticPath(author.avatarPath)}
			/>
			<Flex direction={'column'}>
				<Text variant={'body-2'}>{author.fullName}</Text>
				<Spacing v={'xss'} />
				<Text variant={'body-2'} color={'secondary'}>
					{author.about}
				</Text>
			</Flex>
		</Flex>
	)
}
