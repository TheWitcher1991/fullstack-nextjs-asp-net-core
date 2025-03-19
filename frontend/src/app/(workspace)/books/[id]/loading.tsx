'use client'

import { Flex, Skeleton } from '@gravity-ui/uikit'

import { Spacing } from '~packages/ui'

export default function BookLoading() {
	return (
		<Flex gap={6}>
			<Skeleton
				style={{
					width: 189,
					height: 290,
				}}
			/>
			<Flex direction={'column'}>
				<Skeleton
					style={{
						width: 159,
						height: 24,
					}}
				/>
				<Spacing v={'xss'} />
				<Skeleton
					style={{
						width: 239,
						height: 36,
					}}
				/>
				<Spacing v={'s'} />
				<Skeleton
					style={{
						width: 219,
						height: 44,
					}}
				/>
				<Spacing />
				<Skeleton
					style={{
						width: 424,
						height: 40,
					}}
				/>
				<Spacing />
				<Skeleton
					style={{
						width: 424,
						height: 250,
					}}
				/>
			</Flex>
		</Flex>
	)
}
